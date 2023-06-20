using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Basis.App.Configs;
using UnityEditor;
using UnityEngine;

namespace Basis.Editor.Configs
{
    public class BinaryConfigsExporterWindow : EditorWindow
    {
        #region Constants

        private const string TargetFolder = "Assets/Resources/BinaryConfigs";

        #endregion

        private static readonly ConfigInfo[] _configInfos = new ConfigInfo[]
        {
            MakeConfigInfo(BinaryConfigId.Localization, new LocalizationConfigImporter(), "export localization config", 0.5F),
        };
        
        private static readonly string _resultPath = Directory.GetCurrentDirectory().Replace('\\', '/');

        private string _spreadsheetId = "1IYnRVHuRNjQYA9YMZLUoOh-eMiu1gMURq4lCzRi9QkI";
        private string _userName = "user";
        private CancellationTokenSource _tokenSource;
        private bool _repaint;
        private string _stage;
        private float _progress;

        private static ConfigInfo MakeConfigInfo(BinaryConfigId binaryConfigId, IConfigImporter importer, string stage, float progress)
        {
            var id = binaryConfigId.ToString();
            var targetFileName = $"{TargetFolder}/{BinaryConfigManager.GetBinaryConfigFileName(binaryConfigId)}";
            return new ConfigInfo
            {
                Id = id,
                TargetFileName = targetFileName,
                Importer = importer,
                Stage = stage,
                Progress = progress
            };
        }

        private static string GetResultFileName(string resultPath)
        {
            return $"{ resultPath }/configs.bin";
        }

        private void Import()
        {
            if (_tokenSource != null)
            {
                return;
            }
            Task.Run(ImportAsync);
        }

        private void Cancel()
        {
            _tokenSource?.Cancel();
        }

        private async void ImportAsync()
        {
            _tokenSource = new CancellationTokenSource();
            try
            {
                UpdateProgress("authorization", 0);
                
                var sheetsService = await GoogleConfigDownloader.CreateSheetsServiceAsync(_userName, _tokenSource.Token);
                var sheetSource = new SheetSource(_spreadsheetId, sheetsService);
                
                var bytes = new byte[_configInfos.Length][];
                for (var i = 0; i < _configInfos.Length; ++i)
                {
                    var configInfo = _configInfos[i];
                    UpdateProgress(configInfo.Stage, configInfo.Progress);
                    bytes[i] = await configInfo.Importer.Import(sheetSource, _tokenSource.Token);
                }
                
                UpdateProgress("saving", 0.99F);
                
                await Task.Run(() =>
                {
                    for (var i = 0; i < _configInfos.Length; ++i)
                    {
                        File.WriteAllBytes(_configInfos[i].TargetFileName, bytes[i]);
                    }
                });
                
                UpdateProgress("done", 1);
                
                await Task.Delay(500);
            }
            catch (OperationCanceledException)
            {
                // nothing
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            finally
            {
                _tokenSource = null;
                _repaint = true;
            }
        }

        private void UpdateProgress(string stage, float progress)
        {
            _stage = stage;
            _progress = progress;
            _repaint = true;
        }

        [MenuItem("Basis/Binary Configs Exporter")]
        private static void Init()
        {
            var window = GetWindow<BinaryConfigsExporterWindow>();
            window.titleContent = new GUIContent("Binary Configs Exporter");
            window.Show();
        }

        private static void DrawSpreadsheetInfo(
            bool readOnly,
            ref string spreadsheetId,
            ref string userName,
            out bool onImportClick)
        {
            GUILayout.BeginVertical(string.Empty, GUI.skin.box);
            var enabled = GUI.enabled;
            GUI.enabled = !readOnly;
            spreadsheetId = EditorGUILayout.TextField("Spreadsheet", spreadsheetId);
            userName = EditorGUILayout.TextField("User Name", userName);
            onImportClick = GUILayout.Button("Import");
            GUI.enabled = enabled;
            GUILayout.EndVertical();
        }

        private static void DrawProgressInfo(out bool onCancelClick, string stage, float progress)
        {
            GUILayout.BeginVertical(string.Empty, GUI.skin.box);
            var rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(18));
            GUILayout.Space(18);
            EditorGUI.ProgressBar(rect, progress, string.Format("{0} {1:P0}", stage, progress));
            EditorGUILayout.EndHorizontal();
            onCancelClick = GUILayout.Button("Cancel");
            GUILayout.EndVertical();
        }

        #region Unity

        private void OnGUI()
        {
            var onImportClick = false;
            var onCancelClick = false;
            var importIsInProgress = _tokenSource != null;
            DrawSpreadsheetInfo(
                importIsInProgress,
                ref _spreadsheetId,
                ref _userName,
                out onImportClick);
            if (importIsInProgress)
            {
                DrawProgressInfo(out onCancelClick, _stage, _progress);
            }
            if (onImportClick)
            {
                Import();
            }
            if (onCancelClick)
            {
                Cancel();
            }
        }

        private void OnDestroy()
        {
            _tokenSource?.Cancel();
        }

        private void Update()
        {
            if (_repaint)
            {
                Repaint();
                _repaint = false;
            }
        }

        #endregion

        #region Types

        private sealed class ConfigInfo
        {
            public string Id;
            public string TargetFileName;
            public IConfigImporter Importer;
            public string Stage;
            public float Progress;
        };

        #endregion
    }
}
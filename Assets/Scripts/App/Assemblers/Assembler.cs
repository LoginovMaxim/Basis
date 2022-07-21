using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace App.Assemblers
{
    public abstract class Assembler
    {
        private readonly Queue<IAssemblerPart> _assemblerParts = new();
        
        protected async Task LaunchAssemblerPartsAsync(params IAssemblerPart[] assemblerParts)
        {
            foreach (var assemblerPart in assemblerParts)
            {
                _assemblerParts.Enqueue(assemblerPart);
            }

            while (_assemblerParts.Count > 0)
            {
                var assemblerPart = _assemblerParts.Peek();
                try
                {
                    Debug.Log($"Launching service: {assemblerPart.GetType()}");
                    await assemblerPart.Launch();
                }
                catch (Exception e)
                {
                    Debug.Log($"Service {assemblerPart.GetType()} was error launch.".WithColor(LoggerColor.Red) +
                              $"\nMessage {e.Message}." +
                              $"\nStacktrace: {e.StackTrace}.");

                    await Task.Delay(100);
                    continue;
                }
                
                _assemblerParts.Dequeue();
                Debug.Log($"Service: {assemblerPart.GetType()} launched successfully".WithColor(LoggerColor.Green));
            }
        }
    }
}
using System;
using System.Diagnostics;

public class CustomTimer : IDisposable
{
    private readonly string m_Name;
    private readonly int m_NumberOfTests;
    private readonly Stopwatch m_StopWatch;

    public CustomTimer(string name, int numberOfTests)
    {
        m_Name = name;
        m_NumberOfTests = numberOfTests;
        m_StopWatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        m_StopWatch.Stop();
        float ms = m_StopWatch.ElapsedMilliseconds;
        UnityEngine.Debug.Log($"{ m_Name} Total: {ms:0.00} ms \n" + 
            $"{(ms / m_NumberOfTests)} ms per test" + $"Number of tests: {m_NumberOfTests:N0}");
    }
}
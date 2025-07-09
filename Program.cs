using System;
using System.Threading;

Console.WriteLine($"[Main] Thread ID: {Thread.CurrentThread.ManagedThreadId}");

// Agendando 5 tarefas no ThreadPool
for (int i = 1; i <= 5; i++)
{
    int tarefaId = i;
    ThreadPool.QueueUserWorkItem(TrabalhoNoThreadPool, tarefaId);
}

Console.WriteLine("[Main] Todas as tarefas foram agendadas no ThreadPool.");
Console.WriteLine("[Main] Aguarde as tarefas serem concluídas (pressione qualquer tecla para sair).");
Console.ReadKey();

// Método que será executado pelas threads do ThreadPool
void TrabalhoNoThreadPool(object? state)
{
    int tarefaId = (int)state!;
    Console.WriteLine($"[ThreadPool] Tarefa {tarefaId} iniciada na Thread ID: {Thread.CurrentThread.ManagedThreadId}");
    Thread.Sleep(1000 + tarefaId * 200); // Simula algum trabalho
    Console.WriteLine($"[ThreadPool] Tarefa {tarefaId} finalizada na Thread ID: {Thread.CurrentThread.ManagedThreadId}");
}

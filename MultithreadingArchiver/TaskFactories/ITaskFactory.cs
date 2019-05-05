﻿///////////////////////////////////////////////////////////
//  ITaskFactory.cs
//  Implementation of the Interface ITaskFactory
//  Generated by Enterprise Architect
//  Created on:      15-апр-2019 23:18:23
//  Original author: A7ttim
///////////////////////////////////////////////////////////

using System;

namespace MultithreadingArchiver
{
    /// <summary>
    /// Интерфейс фабрики задач при работе с файлами
    /// Использован паттерн "Абстрактная фабрика"
    /// </summary>
    interface ITaskFactory
    {
        ITaskInfo CreateReadTaskInfo(Int64 id, Int64 length);
        ITaskInfo CreateProcessTaskInfo(Int64 id, byte[] bytes);
        ITaskInfo CreateWriteTaskInfo(Int64 id, byte[] bytes);
    }
}
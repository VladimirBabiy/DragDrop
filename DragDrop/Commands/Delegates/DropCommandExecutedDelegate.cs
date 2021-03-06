﻿
using DragDrop.Commands.Parameters;

namespace DragDrop.Commands.Delegates
{
    /// <summary>
    /// Drop command executed delegate
    /// </summary>
    /// <param name="sender">
    /// Sender
    /// </param>
    /// <param name="parameter">
    /// Parameter
    /// </param>
    public delegate void DropCommandExecutedDelegate(object sender, DropCommandParameter parameter);

}

﻿namespace DragDrop
{

    /// <summary>
    /// Drop command can execute delegate
    /// </summary>
    /// <param name="sender">
    /// Sender
    /// </param>
    /// <param name="parameter">
    /// Parameter
    /// </param>
    public delegate bool DropCommandCanExecuteDelegate(object sender, DropCommandParameter parameter);

}

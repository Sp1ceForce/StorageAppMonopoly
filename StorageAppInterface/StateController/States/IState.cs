﻿namespace StorageAppInterface.StateController.States
{
    public interface IState
    {
        void OnEnter();
        void OnExit();
    }
}

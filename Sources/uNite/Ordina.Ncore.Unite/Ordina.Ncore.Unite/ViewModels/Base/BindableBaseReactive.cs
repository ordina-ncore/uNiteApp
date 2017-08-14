using ReactiveUI;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ordina.Ncore.Unite.ViewModels.Base
{
    public class BindableBaseReactive : ReactiveObject, INotifyPropertyChanged
    {
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            onChanged?.Invoke();

            OnPropertyChanged(propertyName);

            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            this.RaisePropertyChanged(propertyName);
        }
    }
}
using System;
using System.Reactive.Disposables;

namespace Ordina.Ncore.Unite.Extensions
{
    public static class DisposableExtensions
    {
        public static T DisposeWith<T>(this T disposable, CompositeDisposable compositeDisposables) 
            where T : IDisposable
        {
            if(compositeDisposables != null)
                compositeDisposables.Add(disposable);

            return disposable;
        }
    }
}

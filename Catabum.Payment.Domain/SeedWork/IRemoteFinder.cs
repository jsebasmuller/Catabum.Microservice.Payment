using System;

namespace Catabum.Payment.Domain.SeedWork
{
    public interface IRemoteFinder<T, TKey> : IFinder<T, TKey> where T : IDto where TKey : IComparable
    {
    }
}
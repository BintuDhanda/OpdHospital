using System;

namespace OpdHospital.Models;
public interface IEntity<TKey>
{
    TKey Id { get; set; }
}

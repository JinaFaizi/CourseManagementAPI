using CourseManagement.Service.Interfaces;

namespace CourseManagement.Service.Entities;

public class BaseEntity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
}

public class BaseEntity : BaseEntity<int>
{
    
}
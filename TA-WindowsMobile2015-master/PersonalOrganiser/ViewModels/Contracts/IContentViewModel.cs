namespace PersonalOrganiser.ViewModels.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IContentViewModel
    {
        IEnumerable<TaskModel> Tasks { get; set; }
    }
}

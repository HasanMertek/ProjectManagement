using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAnnouncementService
    {
        IDataResult<List<Announcement>> GetAll();
        IResult Add(Announcement announcement);
        IResult Delete(Announcement announcement);
        IResult Update(Announcement announcement);

        IDataResult<Announcement> GetById(int announcementId);
    }
}

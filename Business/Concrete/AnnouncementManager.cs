using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        //[ValidationAspect(typeof(AnnouncementValidator))]
        public IResult Add(Announcement announcement)
        {
            announcement.Date = DateTime.Now.Date;
            _announcementDal.Add(announcement);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Delete(Announcement announcement)
        {
            _announcementDal.Delete(announcement);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Announcement>> GetAll()
        {
            return new SuccessDataResult<List<Announcement>>(_announcementDal.GetAll(), Messages.SuccessList);
        }

        public IResult Update(Announcement announcement)
        {
            _announcementDal.Update(announcement);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}

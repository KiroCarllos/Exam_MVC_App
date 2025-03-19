using Exam_MVC_App.Data;
using Exam_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_MVC_App.Services.TrackServices
{
    public class TrackServices(AppDBContext _db, IAppDBContextProcedures _sp) : ITrackServices
    {
        public Task<int> createTrack(Track trackRequest)
        {
            return _sp.sp_createtrackAsync(trackRequest.Mng_Id, trackRequest.Name, trackRequest.Hours);
        }

        public Task<int> DeleteTrackAsync(byte Id)
        {
            return _sp.sp_deletetrackAsync(Id);
        }

        public Track? GetTrackById(byte Id)
        {
            return _db.Tracks.Include(t => t.Mng).FirstOrDefault(t => t.Id == Id);

        }

        public List<Track> GetTracks()
        {
            return _db.Tracks.Include(t => t.Mng).ToList();
        }

        public Task<int> UpdateTrackAsync(byte Id, Track trackRequest)
        {
            return _sp.sp_updatetrackAsync(Id ,trackRequest.Name, trackRequest.Hours, trackRequest.Mng_Id);
        }
    }
}
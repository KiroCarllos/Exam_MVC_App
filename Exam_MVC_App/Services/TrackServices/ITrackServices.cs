using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.TrackServices
{
    public interface ITrackServices
    {
        Task<int> createTrack(Track trackRequest);
        List<Track> GetTracks();
        Track? GetTrackById(byte Id);
        Task<int> UpdateTrackAsync(byte Id, Track trackRequest);
        Task<int> DeleteTrackAsync(byte Id);
    }
}

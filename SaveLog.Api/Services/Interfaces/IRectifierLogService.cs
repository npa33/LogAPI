using Contracts.Domains.Interfaces.MongoDb;
using SaveLog.Api.DTOs;
using SaveLog.Api.Entities;
using SaveLog.Api.Extensions;

namespace SaveLog.Api.Services.Interfaces
{
    public interface IRectifierLogService : IMongoDbRepositoryBase<RectifierLogEntry>
    {
        Task<IEnumerable<RectifierLogEntryDto>> GetAllBySerialAsync(string serial);
        //Task<IEnumerable<RectifierLogEntryDto>> GetAllByTimesIdAsync(string timesId);
        //Task<IEnumerable<RectifierLogEntryDto>> GetAllByWorkOrderAsync(string workOrder);
        Task<PagedList<RectifierLogEntryDto>> GetAllBySerialPagingAsync(GetRectifierLogPagingQuery query);
        Task<RectifierLogEntryDto> GetByIdAsync(string id);
        Task<RectifierLogEntryDto> AddLogAsync(RectifierLogEntryAddDto model);
        Task DeleteByDocumentNoAsync(string documentNo);
    }
}

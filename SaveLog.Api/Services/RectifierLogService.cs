using AutoMapper;
using Infrastructure.Common;
using Infrastructure.Extensions.MogoDb;
using MongoDB.Bson;
using MongoDB.Driver;
using SaveLog.Api.DTOs;
using SaveLog.Api.Entities;
using SaveLog.Api.Extensions;
using SaveLog.Api.Services.Interfaces;

namespace SaveLog.Api.Services
{
    public class RectifierLogService : MongoDbRepository<RectifierLogEntry>, IRectifierLogService
    {
        private readonly IMapper _mapper;

        public RectifierLogService(IMongoClient client, DatabaseSettings settings, IMapper mapper) : base(client, settings)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<RectifierLogEntryDto>> GetAllBySerialAsync(string serial)
        {
            var entities = await FindAll()
                .Find(x => x.Serial.Equals(serial))
                .ToListAsync();
            var result = _mapper.Map<IEnumerable<RectifierLogEntryDto>>(entities);

            return result;
        }

        public async Task<PagedList<RectifierLogEntryDto>> GetAllByItemNoPagingAsync(GetRectifierLogPagingQuery query)
        {
            var filterSearchTerm = Builders<RectifierLogEntry>.Filter.Empty;
            var filterItemNo = Builders<RectifierLogEntry>.Filter.Eq(s => s.Serial, query.Serial());
            if (!string.IsNullOrEmpty(query.SearchTerm))
                filterSearchTerm = Builders<RectifierLogEntry>.Filter.Eq(s => s.Serial, query.SearchTerm);

            var andFilter = filterItemNo & filterSearchTerm;

            var pagedList = await Collection.PaginatedListAsync(andFilter, query.PageIndex, query.PageSize);
            var items = _mapper.Map<IEnumerable<RectifierLogEntryDto>>(pagedList);
            var result = new PagedList<RectifierLogEntryDto>(items, pagedList.GetMetaData().TotalItems, query.PageIndex,
                query.PageSize);
            return result;
        }

        public async Task<RectifierLogEntryDto> GetByIdAsync(string id)
        {
            var filter = Builders<RectifierLogEntry>.Filter.Eq(s => s.Id, id);
            var entity = await FindAll().Find(filter).FirstOrDefaultAsync();
            var result = _mapper.Map<RectifierLogEntryDto>(entity);

            return result;
        }

        public async Task<RectifierLogEntryDto> AddLogAsync(RectifierLogEntryAddDto model)
        {
            var itemToAdd = new RectifierLogEntry(ObjectId.GenerateNewId().ToString())
            {
               Serial=model.Serial,
               AcVolt=model.AcVolt,
               DcVolt=model.DcVolt,
               CurrLimit=model.CurrLimit,
               DcCurr=model.DcCurr,
               LlcVer=model.LlcVer,
               PfcVer=model.PfcVer,
               WorkOrder=model.WorkOrder,
               StatusCode=model.StatusCode,
               Temp=model.Temp,
               TimesId=model.TimesId,
               Process=model.Process
            };
            await CreateAsync(itemToAdd);
            var result = _mapper.Map<RectifierLogEntryDto>(itemToAdd);

            return result;
        }
        public async Task DeleteByDocumentNoAsync(string documentNo)
        {
            var filter = Builders<RectifierLogEntry>.Filter.Eq(s => s.Serial, documentNo);
            await Collection.DeleteManyAsync(filter);
        }

        public Task<PagedList<RectifierLogEntryDto>> GetAllBySerialPagingAsync(GetRectifierLogPagingQuery query)
        {
            throw new NotImplementedException();
        }
    }
}

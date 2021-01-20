using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data.DataContext;
using Web.Data.Entities;

namespace Web.Application.MEvent
{
    public class EventService : IEventService
    {
        private readonly DataDbContext _context;
        public EventService (DataDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(EventRequest request)
        {
            var _event = new Event()
            {
                sukien = request.sukien,
                website = request.website,
                nhatochuc = request.nhatochuc,
                eventprogram = request.eventprogram,
                surveryduration = request.surveryduration,
                diadiem = request.diadiem,
                congty = request.congty,
                nguoiphutrach = request.nguoiphutrach,
                ngaybatdau = request.ngaybatdau,
                ngayketthuc = request.ngayketthuc,
                muigio = request.muigio,
                chuyenmuc = request.chuyenmuc,
                twitterhashtag = request.twitterhashtag,
                nguoitoida =request.nguoitoida,
                nguoitoithieu = request.nguoitoithieu

            };
            _context.Events.Add(_event);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(EventRequest request)
        {
            var _event = new Event()
            {
                id =request.id,

            };
            _context.Events.Remove(_event);
            return await _context.SaveChangesAsync();
        }

        public async Task<Event> Details(Guid? id)
        {
            return await _context.Events.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Event> FindById(Guid? id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<List<EventResponse>> GetAll()
        {
            return await _context.Events.Select(x => new EventResponse()
            {
                id = x.id,
                sukien = x.sukien,
                website = x.website,
                nhatochuc = x.nhatochuc,
                eventprogram = x.eventprogram,
                surveryduration = x.surveryduration,
                diadiem = x.diadiem,
                congty = x.congty,
                nguoiphutrach = x.nguoiphutrach,
                ngaybatdau = x.ngaybatdau,
                ngayketthuc = x.ngayketthuc,
                muigio = x.muigio,
                chuyenmuc = x.chuyenmuc,
                twitterhashtag = x.twitterhashtag,
                nguoitoida = x.nguoitoida,
                nguoitoithieu = x.nguoitoithieu
            }).ToListAsync();
        }

        public async Task<int> Update(EventRequest request)
        {
            var _event = new Event()
            {
                id = request.id,
                sukien = request.sukien,
                website = request.website,
                nhatochuc = request.nhatochuc,
                eventprogram = request.eventprogram,
                surveryduration = request.surveryduration,
                diadiem = request.diadiem,
                congty = request.congty,
                nguoiphutrach = request.nguoiphutrach,
                ngaybatdau = request.ngaybatdau,
                ngayketthuc = request.ngayketthuc,
                muigio = request.muigio,
                chuyenmuc = request.chuyenmuc,
                twitterhashtag = request.twitterhashtag,
                nguoitoida = request.nguoitoida,
                nguoitoithieu = request.nguoitoithieu

            };
            _context.Events.Update(_event);
            return await _context.SaveChangesAsync();
        }
    }
}

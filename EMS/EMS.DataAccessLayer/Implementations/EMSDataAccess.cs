
using EMS.DataAccessLayer.Entities;
using EMS.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class EMSDataAccess<T> : IEMSDataAccess<T> where T : class
{
    private readonly EmsContext _context;

    public EMSDataAccess(EmsContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public async Task<T> AddAsync(T data)
    {
        await _context.Set<T>().AddAsync(data);
        return data;
    }

    public async Task<string> FindByEmailAsync(string email)
    {
        var user = await _context.Employees.FirstOrDefaultAsync(x=>x.Email==email);

        if (user == null)
        {
            return null;
        }

        return user.Email;
    }

    public async Task<List<T>> GetAllAsync()
    {
        var data = await _context.Set<T>().ToListAsync();
        return data;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}

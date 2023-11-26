using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiHuman.Data;
using WebApiHumanModels.Data;

namespace WebApiHuman.Repositories
{
    public class HumanRepository : IGeneralRepository<Human>
    {
        public readonly ILogger<HumanRepository> _logger;
        private readonly DbContextOptionsBuilder<HumanContext> _humanSettings;

        public HumanRepository(IConfiguration configuration, ILogger<HumanRepository> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _humanSettings = new DbContextOptionsBuilder<HumanContext>();
            _humanSettings.UseSqlServer(configuration["ConnectionString"]);
        }

        public async Task<Human> Create(Human addmodel)
        {
            Human result = null;
            try 
            {
               
                using (var context = new HumanContext(_humanSettings.Options))
                {
                    context.Humans.Add(addmodel);
                    await context.SaveChangesAsync();
                    result = addmodel;

                }
            }
            catch (Exception ex) { _logger.LogError($"Exception in @Create :{ex.Message}"); }
            return result; 
        }

        public async Task<Human> Get(int id)
        {
            Human result=null;
            try
            {
                using (var context = new HumanContext(_humanSettings.Options))
                {
                    result = await context.Humans.AsNoTracking().FirstOrDefaultAsync(x => x.HumanId == id);
                }
            }
            catch (Exception ex) { _logger.LogError($"Exception in @Get :{ex.Message}"); }
            return result;
        }

        public async Task<List<Human>> GetAll()
        {
            List<Human> result =null;
            try
            {

                using (var context = new HumanContext(_humanSettings.Options))
                {
                    result = await context.Humans.ToListAsync();

                }
            }
            catch (Exception ex) { _logger.LogError($"Exception in @GetAll :{ex.Message}"); }
            return result;
        }

        public async Task<Human> Update(Human updatemdel)
        {
            Human result = null;
            try
            {

                using (var context = new HumanContext(_humanSettings.Options))
                {
                    var currentHuman = context.Humans.AsNoTracking().FirstOrDefaultAsync(x => x.HumanId == updatemdel.HumanId);
                    if(currentHuman!= null)
                    {
                        context.Humans.Update(updatemdel);
                        await context.SaveChangesAsync();
                        result = updatemdel;
                    }
                    
                   

                }
            }
            catch (Exception ex) { _logger.LogError($"Exception in @Update :{ex.Message}"); }
            return updatemdel;
        }
    }
}

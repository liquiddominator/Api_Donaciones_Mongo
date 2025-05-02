using Api_Donaciones_Mongo.Data;
using Api_Donaciones_Mongo.Models;
using MongoDB.Driver;

namespace Api_Donaciones_Mongo.Services
{
    public class ComentariosService
    {
        private readonly MongoDbContext _context;

        public ComentariosService(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comentario>> GetAllAsync()
        {
            return await _context.Comentarios.Find(Builders<Comentario>.Filter.Empty).ToListAsync();
        }

        public async Task<Comentario> GetByIdAsync(string id)
        {
            var filter = Builders<Comentario>.Filter.Eq(c => c.Id, id);
            return await _context.Comentarios.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Comentario>> GetByUsuarioIdAsync(int usuarioId)
        {
            var filter = Builders<Comentario>.Filter.Eq(c => c.UsuarioId, usuarioId);
            return await _context.Comentarios.Find(filter).ToListAsync();
        }

        public async Task CreateAsync(Comentario comentario)
        {
            await _context.Comentarios.InsertOneAsync(comentario);
        }

        // New methods to fix the errors

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Comentario>.Filter.Eq(c => c.Id, id);
            await _context.Comentarios.DeleteOneAsync(filter);
        }

        public async Task<List<Comentario>> GetByCalificacionAsync(int calificacion)
        {
            var filter = Builders<Comentario>.Filter.Eq(c => c.Calificacion, calificacion);
            return await _context.Comentarios.Find(filter).ToListAsync();
        }

        public async Task<double> GetPromedioCalificacionAsync()
        {
            // Calcular el promedio de calificaciones
            var comentarios = await _context.Comentarios.Find(Builders<Comentario>.Filter.Empty).ToListAsync();

            if (comentarios == null || comentarios.Count == 0)
                return 0;

            return comentarios.Average(c => c.Calificacion);
        }
        public async Task UpdateAsync(string id, Comentario comentario)
        {
            // Ensure the ID matches
            comentario.Id = id;

            // Create a filter to find the document to replace
            var filter = Builders<Comentario>.Filter.Eq(c => c.Id, id);

            // Replace the existing document with the new one
            await _context.Comentarios.ReplaceOneAsync(filter, comentario);
        }
        public async Task<List<Comentario>> GetByDonacionIdAsync(int donacionId)
        {
            var filter = Builders<Comentario>.Filter.Eq(c => c.DonacionId, donacionId);
            return await _context.Comentarios.Find(filter).ToListAsync();
        }
    }
}

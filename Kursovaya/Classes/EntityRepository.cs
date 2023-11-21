using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Classes
{
    internal class EntityRepository
    {
        private string file = Constants.entityFile;

        public List<Entity> Read()
        {
            using (StreamReader sr = new StreamReader(file))
            {
                List<Entity> entities = new List<Entity>();
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if(line != "")
                    {
                        string[] entitySplit = line.Split(';');
                        int entityCost = Convert.ToInt32(entitySplit[1]);
                        Entity entity = new Entity(entitySplit[0], entityCost, entitySplit[2], entitySplit[3], entitySplit[4]);
                        entities.Add(entity);
                    }
                }
                return entities;
            }
        }

        public async void Save(List<Entity> entities)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (Entity entity in entities)
                {
                    string line = entity.ToString();
                    await sw.WriteLineAsync(line);
                }
            }
        }
    }
}

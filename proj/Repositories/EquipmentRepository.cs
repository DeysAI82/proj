using proj.Interfaces;
using proj.Domain;
using proj.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class EquipmentRepository
    {
        public IEnumerable<Equipment> GetAll()
        {
            using var context = new MyDatabaseContext();
            return context.Equipment.ToList();
        }

        public Equipment? Get(int id)
        {
            using var context = new MyDatabaseContext();
            return context.Equipment.FirstOrDefault(e => e.EquipmentId == id);
        }
    }


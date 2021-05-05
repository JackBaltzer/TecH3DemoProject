using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TecH3DemoProject.Api.Domain
{
    public class BaseModel
    {
        // all entities should have an Id
        [Key]
        public int Id { get; set; }

        // all entities need a created at date, this is required.
        [JsonIgnore]
        public DateTime createdAt { get;  set; }

        // all entities can have an updated datetime, this represents the latest update
        [JsonIgnore]
        public DateTime? updatedAt { get; set; }

        // no entites will be deleted from database, instead they get a deleted date
        // and should be filtered out from all queries
        [JsonIgnore]
        public DateTime? deletedAt { get; set; }
    }
}

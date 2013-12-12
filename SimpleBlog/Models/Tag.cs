﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using System.Collections.Generic;

namespace SimpleBlog.Models
{
    public class Tag
    {
        public virtual int Id { get; set; }
        public virtual string Slug { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }

    public class TagMap : ClassMapping<Tag>
    {
        public TagMap()
        {
            Table("tag");

            Id(x => x.Id, x => x.Generator(Generators.Identity));

            Property(x => x.Name, x => x.NotNullable(true));
            Property(x => x.Slug, x => x.NotNullable(true));

            Bag(x => x.Posts, x =>
            {
                x.Key(k => k.Column("tag_id"));
                x.Table("post_tags");
            }, x => x.ManyToMany(k => k.Column("post_id")));
        }
    }
}
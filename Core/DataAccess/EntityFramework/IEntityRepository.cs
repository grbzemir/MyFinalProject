using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    // Core Katmanı Bizim İcin Evrensel bir katmandır. Bu katmanı diğer katmanlar referans almaz.
    // Generic constraint kısıtlama
    // class: referans tip olabilir demek onun dışında int string gibi değer tipler olamaz.
    // IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    // new(): new'lenebilir olmalı. IEntity interface olduğu için newlenemez. Bu yüzden IEntity'i kaldırdık.
    public interface IEntityRepository<T> where T : class, IEntity, new()

    {

        // Expression filtre vermeye yarar. tümünü degilde istedigimiz şeyi getirmede kullanılır.

        // filter(null vermiyorsa tüm datayı getirir. 
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        // Tek bir data getirmek için kullanılır.
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);





    }
}
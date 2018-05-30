using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Štoparica.Model
{
    class ModelStoparice
    {
        private DateTime? _začeto;
        private TimeSpan? _prejšnjiČas;
        public void Start()
        {
            _začeto = DateTime.Now;
            if (!_prejšnjiČas.HasValue)
                _prejšnjiČas = new TimeSpan(0);
        }
        public void Stop()
        {
            if (_začeto.HasValue)
                _prejšnjiČas += DateTime.Now - _začeto.Value;
            _začeto = null;
        }
        public void Reset()
        {
            _prejšnjiČas = null;
            _začeto = null;
        }
        public bool Teče
        {
            get {
                return _začeto.HasValue;
            }
        }
        public TimeSpan? PretečeniČas
        {
            get
            {
                if (_začeto.HasValue)
                {
                    if (_prejšnjiČas.HasValue)
                        return _prejšnjiČas + (DateTime.Now - _začeto.Value);
                    else
                        return DateTime.Now - _začeto.Value;
                }
                else
                    return _prejšnjiČas;
            }
        }
    }
}

namespace Denion.WebService.VerwijsIndex
{
    interface IWorker
    {
        void Abort();
        void Settle();
        object Request { get; set; }
        object Result { get; }
        void UnSettle();
    }

    public abstract class Worker : IWorker
    {
        /// <summary>
        /// Stoppen met zoeken 
        /// </summary>
        protected bool _aborted = false;

        /// <summary>
        /// Verzoek succesvol
        /// </summary>
        protected bool _settled = false;

        /// <summary>
        /// Authorisation record Id, filled by InsertAuthorisation function
        /// </summary>
        protected object _requestid;

        /// <summary>
        /// Result of the webservice call
        /// </summary>
        public abstract object Request
        {
            set;
            get;
        }


        /// <summary>
        /// Result of the webservice call
        /// </summary>
        public abstract object Result
        {
            get;
        }

        /// <summary>
        /// Het database record ID
        /// </summary>
        public object AuthorisationRecordId
        {
            get
            {
                return _requestid;
            }
        }

        /// <summary>
        /// Huidige verzoek afronden en indien verzoek reeds ingediend, nadien weer intrekken
        /// </summary>
        public void Abort()
        {
            _aborted = true;

            if (_settled)
            {
                UnSettle();
            }
        }

        public abstract void Settle();

        public abstract void UnSettle();
    }

}

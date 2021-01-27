using System;

namespace Distrib.Helper.Helpers
{
    /// <summary>
    /// Provides help methods related to the system and its environment for all projects. Must be initialized before use.
    /// </summary>
    public static class SystemHelper
    {
        private const string EnvNameProduction = "Production";
        private const string EnvNameStaging = "Staging";
        private const string EnvNameDevelopment = "Development";
        private const string EnvNameTesting = "Test";

        private static bool _isInitialized;

        #region Properties

        private static bool _isProduction;

        /// <summary>
        /// Gets a value indicating whether the application is running in a Production environment.
        /// </summary>
        public static bool IsProduction
        {
            get
            {
                SystemHelperIsValid();
                return _isProduction;
            }
            private set
            {
                _isProduction = value;
            }
        }

        private static bool _isStaging;

        /// <summary>
        /// Gets a value indicating whether the application is running in a Staging environment.
        /// </summary>
        public static bool IsStaging
        {
            get
            {
                SystemHelperIsValid();
                return _isStaging;
            }
            private set
            {
                _isStaging = value;
            }
        }

        private static bool _isDevelopment;

        /// <summary>
        /// Gets a value indicating whether the application is running in a Development environment.
        /// </summary>
        public static bool IsDevelopment
        {
            get
            {
                SystemHelperIsValid();
                return _isDevelopment;
            }
            private set
            {
                _isDevelopment = value;
            }
        }

        private static bool _isTesting;

        /// <summary>
        /// Gets a value indicating whether the application is running in a Testing environment.
        /// </summary>
        public static bool IsTesting
        {
            get
            {
                SystemHelperIsValid();
                return _isTesting;
            }
            private set
            {
                _isTesting = value;
            }
        }

        #endregion

        /// <summary>
        /// Initialize the <see cref="SystemHelper"/> to be used.
        /// </summary>
        /// <param name="environmentName">The environment the application is running on.</param>
        public static void Initialize(string environmentName)
        {
            switch (environmentName)
            {
                case EnvNameProduction:
                    IsProduction = true;
                    break;
                case EnvNameStaging:
                    IsStaging = true;
                    break;
                case EnvNameDevelopment:
                    IsDevelopment = true;
                    break;
                case EnvNameTesting:
                    IsTesting = true;
                    break;
                default:
                    throw new NotImplementedException($"Environment {environmentName} not implemented yet");
            }

            _isInitialized = true;
        }

        private static void SystemHelperIsValid()
        {
            if (_isInitialized)
            {
                return;
            }

            throw new ArgumentException($"SystemHelper not initialized properly.");
        }
    }
}

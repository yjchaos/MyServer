using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net;
using log4net.Config;
using Photon.SocketServer;
using TaidouCommon;
using TaidouServer.Handlers;
using LogManager = ExitGames.Logging.LogManager;

namespace TaidouServer
{
    class TaidouApplication:ApplicationBase
    {
        private static TaidouApplication _instance;
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();
        public Dictionary<OperationCode,HandlerBase> handlers = new Dictionary<OperationCode, HandlerBase>();

        public static TaidouApplication Instance
        {
            get { return _instance; }
        }
        public TaidouApplication()
        {
            _instance = this;
        }
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new TaidouClientPeer(initRequest);
        }

        protected override void Setup()
        {
            InitLogging();
            log.Debug("application setup complete");
            RegisterHandlers();
            log.Debug("register handler complete");
        }

        protected override void TearDown()
        {
            log.Debug("application teardown");
        }
        protected virtual void InitLogging()
        {
            LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
            GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            GlobalContext.Properties["LogFileName"] = "TD" + this.ApplicationName;
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(this.BinaryPath, "log4net.config")));
        }

        void RegisterHandlers()
        {
            handlers.Add(OperationCode.Login, new LoginHandler());
        }
    }
}

using System;
using WinSCP;
namespace CommonLibrary
{

        public class SftpProcessor : ISftpProcessor
        {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        SessionOptions _sessionOption;

            public string RemoteFiles { get; set; }
            public string  LocalFolder { get; set; }


        public SftpProcessor(string outboundFile, string remoteHost, string remoteUser, string remotePassword, string remoteFingerprint)
        {
            _sessionOption = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = remoteHost,
                UserName = remoteUser,
                Password = remotePassword,  //TODO: Update password
                SshHostKeyFingerprint = remoteFingerprint
            };
         //   _remoteFiles = Settings.Default.RemoteFolder + outboundFile; //_fileName + ".csv";

            LocalFolder = outboundFile;
        }

        public SftpProcessor(string remoteFiles, string localFolder, string hostName, string user, string password,  string fingerPrint)
        {
            _sessionOption = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = hostName,
                UserName = user,
                Password = password,
                SshHostKeyFingerprint = fingerPrint
            };
            LocalFolder = localFolder;
            RemoteFiles = remoteFiles;
        }

        public void SendFiles()
        {

            try
            {
                Log.Info("Starting File Send.");
                using (Session session = new Session())
                {
                    session.Open(_sessionOption);
                    // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    TransferOperationResult transferResult;
                    transferResult = session.PutFiles(LocalFolder, RemoteFiles, false, transferOptions);

                    transferResult.Check();

                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Log.Info("Upload of " + transfer.FileName + " succeeded");
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error("Error sending files: " + e);
                throw;
            }
        }
        /// <summary>
        /// Retrieves files from SCP SFTP site created by payroll
        /// </summary>
        /// <returns></returns>
        public void RetrieveFiles()
        {
            try
            {
                Log.Info("Starting file retrieval.");
                using (Session session = new Session())
                {
                    session.Open(_sessionOption);
                    // Download files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    TransferOperationResult transferResult;
                    transferResult = session.GetFiles(RemoteFiles, LocalFolder, false, transferOptions);

                    // Throw on any error
                    transferResult.Check();

                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Log.Info("Download of " + transfer.FileName + " succeeded");
                    }
                    session.RemoveFiles(RemoteFiles);
                }
            }
            catch (Exception e)
            {

                Log.Error("Error retrieving files: " + e);
                throw;
            }
        }

    }
}

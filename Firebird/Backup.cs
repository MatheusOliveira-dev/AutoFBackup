using FirebirdSql.Data.Services;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;

namespace Firebird
{
	
	public class Backup
    {
		private string logTxt = string.Empty;
		
		private bool _geraLog = false;
		private bool _compactarZip = false;
		private string _dadosDaConexao = string.Empty;
		private List<string> _flagsBackup;
		private string _uidRotinaBackup;
		private string _diretorioBackups;
		private string _extensaoBackups;

		public Backup(bool geraLog, bool compactarZip, string dadosDaConexao, List<string> flagsBackup, 
			string uidRotinaBackup, string diretorioBackups, string extensaoBackups)
        {
			_geraLog = geraLog;
			_compactarZip = compactarZip;
			_dadosDaConexao = dadosDaConexao;
			_flagsBackup = flagsBackup;
			_uidRotinaBackup = uidRotinaBackup;
			_diretorioBackups = diretorioBackups;
			_extensaoBackups = extensaoBackups;
        }

		public bool ExecutaBackup()
        {

			if (!Directory.Exists(_diretorioBackups))
            {
				Shared.Helpers.CriaArquivo(string.Format(@"{0}\LogErroBackup-{1}.txt", _diretorioBackups, _uidRotinaBackup), "Rotina de Backup abortada -> O Diretório de Backups informado não existe!");
				return false;
			}

			FbBackup backupSvc = new FbBackup();

            try
            {
				backupSvc.ConnectionString = _dadosDaConexao;

				foreach (var flag in _flagsBackup)
				{
                    switch (flag)
                    {
                        case "IgnoreLimbo":
							backupSvc.Options = FbBackupFlags.IgnoreLimbo;
							break;
						case "IgnoreChecksums":
							backupSvc.Options = FbBackupFlags.IgnoreChecksums;
							break;
						case "MetaDataOnly":
							backupSvc.Options = FbBackupFlags.MetaDataOnly;
							break;
						case "NoDatabaseTriggers":
							backupSvc.Options = FbBackupFlags.NoDatabaseTriggers;
							break;
						case "NoGarbageCollect":
							backupSvc.Options = FbBackupFlags.NoGarbageCollect;
							break;
						case "NonTransportable":
							backupSvc.Options = FbBackupFlags.NonTransportable;
							break;
						case "OldDescriptions":
							backupSvc.Options = FbBackupFlags.OldDescriptions;
							break;
					}					
				}

				backupSvc.BackupFiles.Add(new FbBackupFile(string.Format(@"{0}\{1}{2}", _diretorioBackups, _uidRotinaBackup, _extensaoBackups), 2048));
				backupSvc.Verbose = true;

				backupSvc.ServiceOutput += new EventHandler<ServiceOutputEventArgs>(BackupSvc_ServiceOutput);

				backupSvc.Execute();

				CompactaBackupZip();
				CriaArquivoLog();

				return true;
			}
            catch (Exception ex)
            {
				Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
					string.Format("Erro na Criação do Arquivo de Backup. As funções de Upload não serão executadas -> {0}", ex.Message));

				Shared.Helpers.CriaArquivo(string.Format(@"{0}\LogErroBackup-{1}.txt", _diretorioBackups, _uidRotinaBackup), ex.Message);
				return false;
			}
		}

		private void CriaArquivoLog()
        {
			if (_geraLog)
			{
				Shared.Helpers.CriaArquivo(string.Format(@"{0}\LogBackup-{1}.txt", _diretorioBackups, _uidRotinaBackup), logTxt);
			}
		}

		private void CompactaBackupZip()
        {
			if (_compactarZip)
            {
				try
				{
					using (ZipFile zip = new ZipFile())
					{
						zip.AddFile(string.Format(@"{0}\{1}{2}", _diretorioBackups, _uidRotinaBackup, _extensaoBackups), "");
						zip.Save(string.Format(@"{0}\{1}.zip", _diretorioBackups, _uidRotinaBackup));
					}
				}
				catch (Exception ex)
				{
					Shared.Helpers.EscreveArquivo(string.Format(@"{0}\LOGERRO-{1}.txt", _diretorioBackups, _uidRotinaBackup),
						string.Format("Erro na Compactação do Arquivo de Backup -> {0}", ex.Message));
					throw ex;
				}
			}
		}
	
        private void BackupSvc_ServiceOutput(object sender, ServiceOutputEventArgs e)
        {
			if (string.IsNullOrWhiteSpace(logTxt))
            {
				logTxt += e.Message.ToString();
			}
            else
            {
				logTxt += "\n" + e.Message.ToString();
			}
        }
    }
}

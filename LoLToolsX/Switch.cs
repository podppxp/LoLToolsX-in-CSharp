﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace LoLToolsX
{

    /// <summary>
    /// 語言切換
    /// </summary>
    class SwitchLang
    {
        string installPath;
        string cd = Directory.GetCurrentDirectory();

        public SwitchLang(string ip)
        {
            installPath = ip;
        }

        //英文
        public void EngGame()
        {
            try
            {
                File.Copy(cd + @"\files\lang\eng\game\fontconfig_en_US.txt", installPath + @"\Game\DATA\Menu\fontconfig_en_US.txt", true);
                File.Copy(cd + @"\files\lang\eng\game\fontconfig_zh_TW.txt", installPath + @"\Game\DATA\Menu\fontconfig_zh_TW.txt", true);
                File.Copy(cd + @"\files\lang\eng\game\Locale.cfg", installPath + @"\Game\DATA\CFG\Locale.cfg", true);
                MessageBox.Show("遊戲語言切換完成: 英文", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.log("遊戲語言切換完成: 英文", Logger.LogType.Info);
            }
            catch (Exception e)
            {
                MessageBox.Show("語言切換失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("語言切換失敗!", Logger.LogType.Error);
                Logger.log(e, Logger.LogType.Error);
            }
        }
        public void EngLobby()
        {
            try
            {
                File.Copy(cd + @"\files\lang\eng\lobby\locale.properties", installPath + @"\Air\locale.properties", true);
                File.Copy(cd + @"\files\lang\eng\lobby\fonts.swf", installPath + @"\Air\css\fonts.swf", true);
                MessageBox.Show("大廳語言切換完成: 英文", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.log("大廳語言切換完成: 英文", Logger.LogType.Info);
            }
            catch (Exception e)
            {
                MessageBox.Show("語言切換失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("語言切換失敗!", Logger.LogType.Error);
                Logger.log(e, Logger.LogType.Error);
            }

        }


        //中文
        public void ChinGame()
        {
            try
            {
                File.Copy(cd + @"\files\lang\cht\game\fontconfig_en_US.txt", installPath + @"\Game\DATA\Menu\fontconfig_en_US.txt", true);
                File.Copy(cd + @"\files\lang\cht\game\fontconfig_zh_TW.txt", installPath + @"\Game\DATA\Menu\fontconfig_zh_TW.txt", true);
                File.Copy(cd + @"\files\lang\cht\game\Locale.cfg", installPath + @"\Game\DATA\CFG\Locale.cfg", true);
                MessageBox.Show("遊戲語言切換完成: 中文", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.log("遊戲語言切換完成: 中文", Logger.LogType.Info);
            }
            catch (Exception e)
            {
                MessageBox.Show("語言切換失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("語言切換失敗!", Logger.LogType.Error);
                Logger.log(e, Logger.LogType.Error);
            }
        }
        public void ChinLobby()
        {
            try
            {
                File.Copy(cd + @"\files\lang\cht\lobby\locale.properties", installPath + @"\Air\locale.properties", true);
                File.Copy(cd + @"\files\lang\cht\lobby\fonts.swf", installPath + @"\Air\css\fonts.swf", true);
                File.Copy(cd + @"\files\lang\cht\lobby\fonts_zh_TW.swf", installPath + @"\Air\css\fonts_zh_TW.swf", true);
                MessageBox.Show("大廳語言切換完成: 中文", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.log("大廳語言切換完成: 中文", Logger.LogType.Info);
            }
            catch (Exception e)
            {
                MessageBox.Show("語言切換失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("語言切換失敗!", Logger.LogType.Error);
                Logger.log(e, Logger.LogType.Error);
            }

        }

    }


    /// <summary>
    /// 伺服器切換
    /// </summary>

    class SwitchServer
    {

        public static void SwitchServerLoc(string installPath, string targetLoc)
        {
            string propPath = installPath + @"\Air\lol.properties";
            string localProp = Directory.GetCurrentDirectory() + @"\files\server_prop\" + targetLoc;
            FileInfo fi = new FileInfo(localProp);
            try
            {
                fi.CopyTo(propPath, true);
                MessageBox.Show("伺服器切換成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.log("伺服器切換成功: " + targetLoc, Logger.LogType.Info);
            }
            catch (Exception e)
            {
                MessageBox.Show("伺服器切換失敗 \n\r 錯誤訊息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("伺服器切換失敗", Logger.LogType.Error);
                Logger.log(e, Logger.LogType.Error);
            }
        }
    }


    /// <summary>
    /// 語音切換
    /// </summary>


    class SwitchSound
    {
        string installPath;
        string soundPath;
        TwTools tt = new TwTools();

        public SwitchSound(string installPath, string soundPath)
        {
            this.installPath = installPath;
            this.soundPath = soundPath;
        }

        //大廳語音切換
        public void SwitchLobby()
        {
            if (!soundPath.Contains("Sound"))
            {
                MessageBox.Show("請選擇正確的Sound資料夾", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("語音切換: Sound 資料夾選擇錯誤", Logger.LogType.Error);
                return;
            }
            try
            {
                tt.pbLobby.Value = 0;
                foreach (string newPath in Directory.GetFiles(soundPath + @"\champions", "*.*", SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(soundPath + @"\champions", installPath + @"\Air\assets\sounds\en_US\champions"), true);
                tt.pbLobby.Value = 50;
                foreach (string newPath in Directory.GetFiles(soundPath + @"\champions", "*.*", SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(soundPath + @"\champions", installPath + @"\Air\assets\sounds\zh_TW\champions"), true);
                tt.pbLobby.Value = 100;
                MessageBox.Show("安裝完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tt.pbLobby.Value = 0;
                Logger.log("大廳語音安裝成功!", Logger.LogType.Info);

            }
            catch (Exception e)
            {
                tt.pbLobby.Value = 0;
                MessageBox.Show("安裝失敗\r\n錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("語音切換: 大廳語音安裝失敗!", Logger.LogType.Error);
                Logger.log(e, Logger.LogType.Error);
            }
        }

        //遊戲語音切換
        public void SwitchGame()
        {
            if (!soundPath.Contains("Sound"))
            {
                MessageBox.Show("請選擇正確的Sound資料夾", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.log("語音切換: Sound 資料夾選擇錯誤", Logger.LogType.Error);
                return;
            }
            //KR
            try
            {
                tt.pbGame.Value = 0;
                File.Copy(soundPath + @"\VOBank_ko_KR.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_ko_KR.fsb", true);
                tt.pbGame.Value = 35;
                File.Copy(soundPath + @"\VOBank_ko_KR.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_zh_TW.fsb", true);
                File.Copy(soundPath + @"\VOBank_ko_KR.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_zh_CN.fsb", true);
                tt.pbGame.Value = 65;
                File.Copy(soundPath + @"\VOBank_ko_KR.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_en_US.fsb", true);
                tt.pbGame.Value = 100;
                MessageBox.Show("安裝完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tt.pbGame.Value = 0;
                Logger.log("大廳語音安裝成功!", Logger.LogType.Info);
            }
            /*
        catch (System.IO.FileNotFoundException)
        {
            tt.pbGame.Value = 0;
            MessageBox.Show("安裝失敗\r\n找不到語音檔案 " , "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
             */
            catch (Exception e)
            {
                Logger.log(e, Logger.LogType.Error);
            }


            try
            {
                tt.pbGame.Value = 0;
                File.Copy(soundPath + @"\VOBank_zh_TW.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_ko_KR.fsb", true);
                tt.pbGame.Value = 35;
                File.Copy(soundPath + @"\VOBank_zh_TW.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_zh_TW.fsb", true);
                File.Copy(soundPath + @"\VOBank_zh_TW.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_zh_CN.fsb", true);
                tt.pbGame.Value = 65;
                File.Copy(soundPath + @"\VOBank_zh_TW.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_en_US.fsb", true);
                tt.pbGame.Value = 100;
                MessageBox.Show("安裝完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tt.pbGame.Value = 0;
                Logger.log("大廳語音安裝成功!", Logger.LogType.Info);
            }
            /*
            catch (System.IO.FileNotFoundException)
            {
                tt.pbGame.Value = 0;
                MessageBox.Show("安裝失敗\r\n找不到語音檔案 ", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             */
            catch (Exception e2)
            {
                Logger.log(e2, Logger.LogType.Error);
            }

            try
            {
                tt.pbGame.Value = 0;
                File.Copy(soundPath + @"\VOBank_zh_CN.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_ko_KR.fsb", true);
                tt.pbGame.Value = 35;
                File.Copy(soundPath + @"\VOBank_zh_CN.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_zh_TW.fsb", true);
                File.Copy(soundPath + @"\VOBank_zh_CN.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_zh_CN.fsb", true);
                tt.pbGame.Value = 65;
                File.Copy(soundPath + @"\VOBank_zh_CN.fsb", installPath + @"\Game\DATA\Sounds\FMOD\VOBank_en_US.fsb", true);
                tt.pbGame.Value = 100;
                MessageBox.Show("安裝完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tt.pbGame.Value = 0;
                Logger.log("大廳語音安裝成功!", Logger.LogType.Info);
            }
            /*
        catch (System.IO.FileNotFoundException)
        {
            tt.pbGame.Value = 0;
            MessageBox.Show("安裝失敗\r\n找不到語音檔案 ", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
             */
            catch (Exception e3)
            {
                Logger.log(e3, Logger.LogType.Error);
            }

        }

    }

}

using System;
using System.IO;
using System.Text;
 
namespace FileSys{

  public class FileObj{

    string csv_header;
    string full_path;
    string file_path;
    string file_name;

    string name_as_full_path;
    string name_as_file_path;
    string name_as_file_name;

    string encord_code;
    string all_text;
    string[] re_ary;
    long re_ary_length;

    Encoding name_as_file_encord;
    Encoding file_encord;
    StreamReader sr;
    StreamWriter sw;

    // エンコードをセット
    public void SetEncode(string enc_code){
      this.encord_code = enc_code;
    }

    // StreamWriter を開く
    public int SrWriterOpen(string f_path,string f_name){
      try{
        this.name_as_file_path = f_path;
        this.name_as_file_name = f_name;
        this.name_as_full_path = f_path + "\\" + f_name;
        this.name_as_file_encord = Encoding.GetEncoding(this.encord_code);
        this.sw = new StreamWriter(this.name_as_full_path, false, this.name_as_file_encord);
      }catch(IOException e){
        Console.WriteLine("{0}",e.GetType().Name);
        return -1;
      }
      return 0;
    }

    // StreamWriterに文字列を書き込む
    public void SrWriterWrite(string wStream){
      this.sw.WriteLine(wStream);
    }

    // StreamWriter を閉じる
    public int SrWriterClose(){
      try{
        this.sw.Close();
      }catch(IOException e){
        Console.WriteLine("{0}",e.GetType().Name);
        return -1;
      }
      return 0;
    }

    // StreamReader を開く
    public int SrReaderOpen(string f_path,string f_name){
      try{
        this.file_path = f_path;
        this.file_name = f_name;
        this.full_path = this.file_path + "\\" + this.file_name;
        this.file_encord = Encoding.GetEncoding(this.encord_code);
        this.sr = new StreamReader(this.full_path, this.file_encord);
      }catch(IOException e){
        Console.WriteLine("エラー：{0}",e.GetType().Name);
        return -1;
      }
      return 0;
    }

    // StreamReader からデータを読み取る。
    public void SrReaderReadToEnd(){
      this.all_text = this.sr.ReadToEnd();
      return ;
    }

    public void SrReaderConWriteLine(){
      Console.WriteLine(this.all_text);
    }

    // StreamReader を閉じる
    public int SrReaderClose(){
      try{
        this.sr.Close();
      }catch(IOException e){
        Console.WriteLine("{0}",e.GetType().Name);
        return -1;
      }
      return 0;
    }

    // 1行目のヘッダを出力
    public string CsvHeader(){
      this.csv_header = this.re_ary[0];
      return this.csv_header;
    }

    // CSV反転後のヘッダを出力
    public string CsvHeaderReverse(){
      this.csv_header = this.re_ary[this.re_ary.Length-1];
      return this.csv_header;
    }

    // ファイルを配列に変換 改行で区切る。
    public void SplitLine(){
      string[] delimcrlf = {"\n","\r"};
      this.re_ary = this.all_text.Replace("\r\n","\n").Split(delimcrlf,StringSplitOptions.None);
    }

    // 指定した要素番号の文字列を返す。
    public string getLine(long index){
      return re_ary[index];
    }

    // 配列の長さを返す。
    public long getLength(){
      this.re_ary_length=re_ary.Length;
      return this.re_ary_length;
    }

    // タブ区切りの文字列を配列に変換
    public string[] SplitTab(string ReadLine){
      string[] delimtab = {"\t"};
      return ReadLine.Split(delimtab,StringSplitOptions.None);
    }

    // カンマ区切りの文字列を配列に変換
    public string[] SplitComma(string ReadLine){
      string[] delimtab = {","};
      return ReadLine.Split(delimtab,StringSplitOptions.None);
    }

    // 配列を逆に並び替える。
    public void ArrayReverse(){
      Array.Reverse(this.re_ary);
    }

  }
}
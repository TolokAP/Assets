
using UdpKit;


<<<<<<< dev
<<<<<<< dev
public class ProtocolTokenLogin : Photon.Bolt.IProtocolToken
=======
public class ProtocolTokenLogin : Bolt.IProtocolToken
>>>>>>> Добавлен UI эллементы
=======
public class ProtocolTokenLogin : Photon.Bolt.IProtocolToken
>>>>>>> все внесено
{
    public string Username { get; set; }
    public string Password { get; set; }

    public string NamePlayer { get; set; }

    public bool Create { get; set; }

    public string Class { get; set; }

    public void Read(UdpPacket packet)
    {
        Username = packet.ReadString();
        Password = packet.ReadString();
        NamePlayer = packet.ReadString();
        Create = packet.ReadBool();
        Class = packet.ReadString();
    }

    public void Write(UdpPacket packet)
    {
        packet.WriteString(Username);
        packet.WriteString(Password);
        packet.WriteString(NamePlayer);
        packet.WriteBool(Create);
        packet.WriteString(Class);
    }

   
}

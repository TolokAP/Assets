using UdpKit;


<<<<<<< dev
<<<<<<< dev
public class NetworkIDToken : Photon.Bolt.IProtocolToken
=======
public class NetworkIDToken : Bolt.IProtocolToken
>>>>>>> Добавлен UI эллементы
=======
public class NetworkIDToken : Photon.Bolt.IProtocolToken
>>>>>>> все внесено
{
    public ulong NetworkID { get; set; }
    public int Hand { get; set; }

    public int ID { get; set; }
    public void Read(UdpPacket packet)
    {
        NetworkID = packet.ReadULong();
        Hand = packet.ReadInt();
        ID = packet.ReadInt();
    }

    public void Write(UdpPacket packet)
    {
        packet.WriteULong(NetworkID);
        packet.WriteInt(Hand);
        packet.WriteInt(ID);
    }
}

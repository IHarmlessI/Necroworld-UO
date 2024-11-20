using System;

namespace Server.Items
{
	public class RoundWeddingTable : Item
	{
		[Constructable]
		public RoundWeddingTable()
			: base(0x9E8D)
		{
			Movable = true;
			
			Name = "round wedding table";

			Weight = 1.0;
		}

		public RoundWeddingTable(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}
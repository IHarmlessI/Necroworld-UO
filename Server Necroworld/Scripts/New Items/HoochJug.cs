using System;

namespace Server.Items
{
	[Flipable(0x495E, 0x495F)]
	public class HoochJug : Item
	{
		[Constructable]
		public HoochJug()
			: base(0x495E)
		{
			Movable = true;
			
			Name = "hooch jug";

			Weight = 1.0;
		}

		public HoochJug(Serial serial)
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
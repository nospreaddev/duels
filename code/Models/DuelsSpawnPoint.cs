using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Models
{
	internal class DuelsSpawnPoint
	{
		public DuelsSpawnPointEntity Entity { get; set; }
		public int Index { get; set; }

		public DuelsSpawnPoint(DuelsSpawnPointEntity spawn, int index) {
			Entity = spawn;
			Index = index;
		}
	}
}

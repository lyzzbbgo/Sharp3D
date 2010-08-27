using System.Collections.Generic;
using Sharp3D.Scene.Cameras;
using Sharp3D.Scene.Lights;
using Sharp3D.Scene.Materials;
using Sharp3D.Scene.Models;
using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene
{
    public interface IScene
    {
        ICollection<ICamera> Cameras { get; }

        ICollection<ILight> Lights { get; }

        ICollection<IMaterial> Materials { get; }

        ICollection<IModel> Models { get; }

        Color Background { get; set; }
    }
}
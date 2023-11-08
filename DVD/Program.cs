using Raylib_cs;

public class DVD{

    public Vector2I WindowSize = new Vector2I(1920/2, 540);

    public Vector2 ImagePosition = new Vector2(0, 0);
    public Vector2 ImageSpeed = new Vector2(0.125f, 0.125f);
    public Vector2 ImageSize => new Vector2(LogoTexture.Width, LogoTexture.Height) * ImageScale;

    public Vector2 ImageBottomRight => ImagePosition + ImageSize;

    public Texture2D LogoTexture;

    public float ImageScale = 0.125f;

    public float Time;

    public static void Main(){
        new DVD().Init();
    }

    public void Init(){
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_HIGHDPI | ConfigFlags.FLAG_WINDOW_UNDECORATED | ConfigFlags.FLAG_WINDOW_TRANSPARENT | ConfigFlags.FLAG_WINDOW_ALWAYS_RUN | ConfigFlags.FLAG_WINDOW_UNFOCUSED | ConfigFlags.FLAG_WINDOW_TOPMOST | ConfigFlags.FLAG_WINDOW_MOUSE_PASSTHROUGH);
        Raylib.InitWindow(WindowSize.x, WindowSize.y, $"DVD");

        Start();

        while(!Raylib.WindowShouldClose()){

            Raylib.BeginDrawing();
            
            Raylib.ClearBackground(Color.BLANK);

            Time += Raylib.GetFrameTime();

            Draw();


            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    
    }

    public void Start(){
        LogoTexture = Raylib.LoadTexture(AppDomain.CurrentDomain.BaseDirectory + "/Logo.png");
        ImagePosition = new Vector2(Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor()) / 2 , Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor()) / 2) - ImageSize / 2;
        int xScale = Raylib.GetRandomValue(0, 1);
        int yScale = Raylib.GetRandomValue(0, 1);
        ImageSpeed *= new Vector2(xScale == 0 ? -1 : 1, yScale == 0 ? -1 : 1);
    }

    public void Draw(){
        
        float r = ((MathF.Sin(Time) + 1) / 2) * 255;
        float g = ((MathF.Sin(Time + 2345) + 1) / 2) * 255;
        float b = 0;

        Raylib.DrawTextureEx(LogoTexture, new Vector2(0, 0), 0, ImageScale, new Color((byte)r, (byte)g, (byte)b, (byte)255));


        if (ImagePosition.x <= 0) ImageSpeed.x *= -1;
        if (ImagePosition.y <= 0) ImageSpeed.y *= -1;
        if (ImageBottomRight.y >= Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor())) ImageSpeed.y *= -1;
        if (ImageBottomRight.x >= Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor())) ImageSpeed.x *= -1;

        ImagePosition += ImageSpeed;

        Raylib.SetWindowSize((int)ImageSize.x, (int)ImageSize.y);

        Raylib.SetWindowPosition((int)MathF.Round(ImagePosition.x), (int)MathF.Round(ImagePosition.y));
    }

}
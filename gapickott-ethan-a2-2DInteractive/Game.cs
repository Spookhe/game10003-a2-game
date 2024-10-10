using System;
using System.Numerics;

namespace Game10003
{
    public class Game
    {
        // Define colors
        Color sand = new Color(0xF4, 0xA4, 0x60); // Sand
        Color water = new Color(0x0B, 0x3D, 0x6A); // Water
        Color wave = new Color(0xAD, 0xD8, 0xE6); // Waves
        Color coralOrange = new Color(0xFF, 0x45, 0x00); // Orange Coral
        Color coralGreen = new Color(0x68, 0xD8, 0x51); // Green Coral
        Color coralPurple = new Color(0x6A, 0x51, 0x8A); // Purple Coral
        Color anchorColor = new Color(0x8B, 0x8B, 0x8B); // Gray for anchor
        Color bubbleColor = new Color(0xB0, 0xE0, 0xE6, 128); // Light blue alpha bubbles
        Color clickBubbleColor = new Color(0xFF, 0xA0, 0xA0, 128); // Purple bubbles on click

        // Bubbles
        float[] xCoordinates;
        float[] yCoordinates;
        float[] clickXCoordinates; // For clicked bubbles
        float[] clickYCoordinates; // For clicked bubbles
        float bubbleRadius = 5;
        int bubbleCount = 50; // Initial bubble count
        int currentClickBubbleCount = 0; // Tracks clicked bubbles

        public void Setup()
        {
            Window.SetTitle("2D Interactive Underwater");
            Window.SetSize(400, 400);

            xCoordinates = new float[bubbleCount];
            yCoordinates = new float[bubbleCount];
            clickXCoordinates = new float[bubbleCount]; // Initializes clicked bubble arrays
            clickYCoordinates = new float[bubbleCount];

            // Initializes random bubble positions
            for (int i = 0; i < bubbleCount; i++)
            {
                xCoordinates[i] = Random.Integer(0 + (int)bubbleRadius, Window.Width - (int)bubbleRadius);
                yCoordinates[i] = Random.Integer(100, 330); // Ensures the bubbles do not overlap sand
            }
        }

        public void Update()
        {
            // Sets background colour creating an ocean
            Window.ClearBackground(water);

            // Draw waves
            Draw.FillColor = wave;
            for (int index = 0; index < 8; index++) // 8 semicircles looped for waves
            {
                int xOffset = index * 50; // Spaces the semi-circles
                Draw.Circle(25 + xOffset, 20, 40); // Draws semicircles for waves
            }

            // Draws alpha bubbles
            Draw.FillColor = bubbleColor;
            for (int i = 0; i < xCoordinates.Length; i++)
            {
                Draw.Circle(xCoordinates[i], yCoordinates[i], bubbleRadius);
            }

            // Draws bubbles on click
            Draw.FillColor = clickBubbleColor;
            for (int i = 0; i < currentClickBubbleCount; i++)
            {
                Draw.Circle(clickXCoordinates[i], clickYCoordinates[i], bubbleRadius); // Draw bubble on clicked coords
            }

            // Draw the boat
            Draw.FillColor = new Color(0x8B, 0x45, 0x00); // Brown color for the boat
            Draw.Circle(205, 5, 65);
            Draw.Circle(195, -10, 80);
            Draw.Circle(215, -10, 80);

            // Draws sand
            Draw.LineSize = 0;
            Draw.FillColor = sand;
            Draw.Rectangle(0, 340, 400, 60);

            // Draws Orange Coral
            Draw.FillColor = coralOrange;
            Draw.Circle(50, 330, 17);
            Draw.Circle(50, 310, 17);
            Draw.Circle(50, 290, 17);
            Draw.Circle(70, 270, 17);

            // Draws Green Coral
            Draw.FillColor = coralGreen;
            Draw.Circle(150, 330, 17);
            Draw.Circle(150, 310, 17);
            Draw.Circle(150, 290, 17);
            Draw.Circle(150, 270, 17);
            Draw.Circle(150, 250, 17);
            Draw.Circle(170, 250, 17);
            Draw.Circle(190, 230, 17);
            Draw.Circle(190, 210, 17);
            Draw.Circle(210, 190, 17);

            // Draws Purple Coral
            Draw.FillColor = coralPurple;
            Draw.Circle(250, 310, 17);
            Draw.Circle(270, 290, 17);
            Draw.Circle(270, 230, 17);
            Draw.Circle(290, 330, 17);
            Draw.Circle(290, 310, 17);
            Draw.Circle(290, 290, 17);
            Draw.Circle(290, 270, 17);
            Draw.Circle(290, 250, 17);
            Draw.Circle(310, 250, 17);
            Draw.Circle(330, 230, 17);
            Draw.Circle(330, 270, 17);

            // Draws Boat Anchor
            Draw.FillColor = anchorColor;
            Draw.Circle(250, 50, 5);
            Draw.Circle(250, 60, 5);
            Draw.Circle(250, 70, 5);
            Draw.Circle(250, 80, 5);
            Draw.Circle(250, 90, 5);
            Draw.Circle(250, 100, 5);
            Draw.Circle(250, 110, 5);
            Draw.Circle(240, 110, 5);
            Draw.Circle(260, 110, 5);
            Draw.Circle(230, 100, 5);
            Draw.Circle(270, 100, 5);

            // Checks for mouse clicks
            if (Input.IsMouseButtonPressed(0)) // Left mouse button
            {
                // Get mouse position
                float mouseX = Input.GetMouseX();
                float mouseY = Input.GetMouseY();

                // Add three bubbles in a random diagonal pattern
                if (currentClickBubbleCount + 3 <= bubbleCount)
                {
                    clickXCoordinates[currentClickBubbleCount] = mouseX; // First bubble on click
                    clickYCoordinates[currentClickBubbleCount] = mouseY;

                    clickXCoordinates[currentClickBubbleCount + 1] = mouseX - Random.Integer(5, 15); // Second bubble with randomization
                    clickYCoordinates[currentClickBubbleCount + 1] = mouseY + Random.Integer(10, 20);

                    clickXCoordinates[currentClickBubbleCount + 2] = mouseX + Random.Integer(5, 15); // Third bubble with randomization
                    clickYCoordinates[currentClickBubbleCount + 2] = mouseY + Random.Integer(20, 30);

                    currentClickBubbleCount += 3; // Increases the count by three
                }
            }

            Text.Draw("Program by 000923124", 30, 360); // Program credentials
        }
    }
}
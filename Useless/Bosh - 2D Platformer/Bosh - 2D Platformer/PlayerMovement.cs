// See https://aka.ms/new-console-template for more information

using System.Numerics;

float speed = 15f;

float h = Input.GetAxis("Horizontal");
float v = Input.GetAxis("Vertical");
        
Vector2 pos =  transform.position;
        
pos.x += h * speed * Time.deltaTime;
pos.y += v * speed * Time.deltaTime;

transform.position = pos;
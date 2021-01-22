
void setup() {
  size(500, 500);
}
void draw() {
  background(128);
  
  float time = millis()/1000.0;
  
  float x = sin(time) * 200 + width/2;
  float y = cos(time) * 200 + height/2;
  
  ellipse(width/2, height/2, 400, 400);
  
  ellipse(x, height/2, 20, 20);
  ellipse(width/2, y, 20, 20);
  
  ellipse(x, y, 50, 50);
  
}

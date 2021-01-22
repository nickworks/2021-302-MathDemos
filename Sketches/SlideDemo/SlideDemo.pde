float x1, x2, x3;

float v2 = 0;

void setup(){
  size(500,500);
}
void draw(){
  background(128);
  
  // simple, linear slide:
  
  if(x1 < mouseX) x1 += 5;
  else if(x1 > mouseX) x1 -= 5;
  
  // euler physics slide:
  
  if(x2 < mouseX) v2 ++;
  if(x2 > mouseX) v2 --;
  
  x2 += v2;
  
  // damping : exponential slide : asymototic easing
  
  //x3 += (mouseX - x3) * .05;
  
  x3 = lerp(x3, mouseX, .05);
  
  
  ellipse(x1, 100, 30, 30);
  ellipse(x2, 200, 30, 30);
  ellipse(x3, 300, 30, 30);
}

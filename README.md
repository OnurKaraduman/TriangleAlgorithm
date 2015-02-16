# TriangleAlgorithm
This application is running on desktop. It find triangles in points how much you added.
Also can find min area of triangle when you select a point. 
TRIANGLE  ALGORITM

Create Vertex

	Firstly, we create vertex point for triangle. Creating may be randomly or not randomly.This is not matter. While we are creating point, we have to keep into array.

	For this, we have to define a array like following defined.
	List<Point> myPoint = new List<System.Drawing.Point>();
	Now, lets create points entering to TextBox.
	//defined for x, y coordinate.
	int a, b;

            //defined for x, y coordinate.
       while (i < Convert.ToInt32(textBox1.Text))
              {
             //create for x
              	              a = rnd.Next(210, frm.Width - 10);
             //create for y
               	 b = rnd.Next(20, frm.Height - 10);
              //add the coordinate to array of myPoint
              myPoint.Add(new System.Drawing.Point(a, b));
              //draw for point like a full Ellipse
                              graphicObj.FillEllipse(myBrush2, myPoint[i].X, myPoint[i].Y, 10, 10);
		 //write point number above point
               	  graphicObj.DrawString(i.ToString(), drawFont, drawBrush, a, b - 20);
             		   i++;
            }


	After that, we have all points for triangle and now we will try to find all kombination triangle.
	We create a structre as keeping triangle vertex.


	public struct triangle
        	{
            //A
            public int vertex1;
            //B
            public int vertex2;
            //C
            public int vertex3;
      	  }

	

	We have points. Algoritm will be following pictures.

	We take the first two point.Try all kombination with surviving points.

	This time, take the firs two except for first point.We can do same logic.
	Total kombination is 9.
































  After explaining the logic of algoritm, now  we can write code.

    //find all triangle
    void FindTriangle()
	{
		//counter counting all triangle number
		int x = 0;		
		//first point
		for (int a = 0; a < gObjects.Length-1; a++) {
			//second point
			for (int i = a + 1; i <= gObjects.Length-1; i++) {
				//third point
				for (int j = i + 1; j <= gObjects.Length-2; j++) {
					
					//controling whether located on same x line
					//if all points is located same line then this points dont 					create triangle.
					if (gObjects[a].transform.position.x == 									gObjects[i].transform.position.x  &&  
						gObjects[i].transform.position.x == 								gObjects[j].transform.position.x)
					{
					}
					
					//controling whether located on same y line
					//if all points is located same line then this points dont 					create triangle.
					else if (gObjects[a].transform.position.z == 									gObjects[i].transform.position.z  &&  
							gObjects[i].transform.position.z == 								gObjects[j].transform.position.z) {	
					}
					





					//controling whether located same slope
					//if all points is located same slope then this points 					dont create triangle.
					else if ( gObjects[a].transform.position.z / 									gObjects[a].transform.position.x == 								gObjects[i].transform.position.z / 								gObjects[i].transform.position.x  && 								gObjects[i].transform.position.z / 										gObjects[i].transform.position.x == 									gObjects[j].transform.position.z / 										gObjects[j].transform.position.x)
					{
						
					}
					
					//finding points of triangle
					else {
						triangle[x].vertex1 = a;
						triangle[x].vertex2 = i;
						triangle[x].vertex3 = j;
						x ++;
					}
				}
			}
		}
		Debug.Log("Found all triangle : "+x.ToString());
	}
   


  All triangle was found but we have to find which triangle is consisting of P point.For this, we have to order A, B, C like following triangle.This order is important (A, B, C) .It have to be counterclockwise.



    //Assign A,B,C
    void AssignABC(int a)
	{
		int vertex = 0;
		
		//trying to find A
		//Point having smallest y axis is A
		if (gObjects[triangle[a].vertex1].transform.position.z < 						gObjects[triangle[a].vertex2].transform.position.z)
        		{
			if (gObjects[triangle[a].vertex1].transform.position.z < 						gObjects[triangle[a].vertex3].transform.position.z)
       	     		{
				A = gObjects[triangle[a].vertex1];
				vertex = 1;
			}
			else {
				A = gObjects[triangle[a].vertex3];
				vertex = 3;
			}
		}
		else if (gObjects[triangle[a].vertex2].transform.position.z < 						gObjects[triangle[a].vertex3].transform.position.z)
       	 	{
			A = gObjects[triangle[a].vertex2];
			vertex = 2;
		 }


		else if (gObjects[triangle[a].vertex2].transform.position.z > 						gObjects[triangle[a].vertex3].transform.position.z)
       	 	{
			A = gObjects[triangle[a].vertex3];
            			vertex = 3;
		 }

        //trying to find B and C point of triangle
	 //Point have smallest slope between  A and own is B. Other is C.
        switch (vertex)
     	   {
			//if vertex1 is A
            case 1:

                //slope s1 and s2
                double s1 = (double) (gObjects[triangle[a].vertex2].transform.position.z-						A.transform.position.z) /                   								 (gObjects[triangle[a].vertex2].transform.position.x - 								A.transform.position.x );
                double s2 = (double) (gObjects[triangle[a].vertex3].transform.position.z-						A.transform.position.z) /										(gObjects[triangle[a].vertex3].transform.position.x - 									A.transform.position.x );
                if(s1 < 0)
                	     {
				
			//if s1<0 and s2>=0 then
                    if(s2 >= 0)
                    		{
                       		 B = gObjects[triangle[a].vertex3];
                       		 C = gObjects[triangle[a].vertex2];
                    	}
			//if s1<0 and s2<0 then
              else
	              	  {
					
              	    //s1, s2<0 and |s1| < |s2|
                        if( System.Math.Abs(s1) < System.Math.Abs(s2))
                        		        {
                            				B = gObjects[triangle[a].vertex3];
                            				C = gObjects[triangle[a].vertex2];
                        		         }
					
		          //s1,s2<0 and |s1| > |s2|
                        else if(Math.Abs(s1) > Math.Abs(s2))
                        		      {
		                            B = gObjects[triangle[a].vertex2];
                            			C = gObjects[triangle[a].vertex3];
		                        }
                    	     }
                }
        else if (s1 > 0)
                {
                if (s2 > 0)
	                    {
                       if (s1 > s2)
             		                 {
		                            C = gObjects[triangle[a].vertex2];
                            			B = gObjects[triangle[a].vertex3];
                        		   }
                      else if (s1 < s2)
                        		  {
		                            C = gObjects[triangle[a].vertex3];
                            B = gObjects[triangle[a].vertex2];
                        }
                    }
                    else if (s2 < 0)
                    {
                        B = gObjects[triangle[a].vertex2];
                        C = gObjects[triangle[a].vertex3];
                    }

                }break;	
		  //if vertex2 is A
            case 2:
                //slope s1 and s2
                double s3 = (double) (gObjects[triangle[a].vertex1].transform.position.z- 						A.transform.position.z) /   										(gObjects[triangle[a].vertex1].transform.position.x - 									A.transform.position.x );
                double s4 = (double) (gObjects[triangle[a].vertex3].transform.position.z-						A.transform.position.z) /               									(gObjects[triangle[a].vertex3].transform.position.x - 									A.transform.position.x );
                if(s3 < 0)
                                 {
                    if(s4 >= 0)
                    		{
		                        B = gObjects[triangle[a].vertex3];
		                        C = gObjects[triangle[a].vertex1];
	                            }
                    else
	             	           {
                        if( System.Math.Abs(s3) < System.Math.Abs(s4))
	                                   {
                         			   B = gObjects[triangle[a].vertex3];
		                            C = gObjects[triangle[a].vertex1];
                        		       }

            		 else if(Math.Abs(s3) > Math.Abs(s4))
                       		 {
                            	       		B = gObjects[triangle[a].vertex1];
                                   		C = gObjects[triangle[a].vertex3];
                        		}
                    	       }
               	   }
               else if (s3 > 0)
                	    {
                    if (s4 > 0)
                    		{
                        if (s3 > s4)
                        		       {
		                            C = gObjects[triangle[a].vertex1];
                            			B = gObjects[triangle[a].vertex3];
                        		      }
                        else if (s3 < s4)
                       		 {
		                            C = gObjects[triangle[a].vertex3];
                            			B = gObjects[triangle[a].vertex1];
                        		    }
                    	       }
                else if (s4 < 0)
                    	   {
                       		 B = gObjects[triangle[a].vertex1];
	                            C = gObjects[triangle[a].vertex3];
                  	     }

                }break;
		   //if vertex3 is A
                case 3:
                //slope s1 and s2
                double s5 = (double) (gObjects[triangle[a].vertex2].transform.position.z-						A.transform.position.z) /     									(gObjects[triangle[a].vertex2].transform.position.x - 									A.transform.position.x );
                double s6 = (double) (gObjects[triangle[a].vertex1].transform.position.z-						A.transform.position.z) /                    								(gObjects[triangle[a].vertex1].transform.position.x - 									A.transform.position.x );
                if(s5 < 0)
              	  	     {
                    if(s6 >= 0)
                    		{
		                        B = gObjects[triangle[a].vertex1];
		                        C = gObjects[triangle[a].vertex2];
	                             }
                    else
	         	            {
                        if( System.Math.Abs(s5) < System.Math.Abs(s6))
                        	                     {
		                            B = gObjects[triangle[a].vertex1];
		                            C = gObjects[triangle[a].vertex2];
                        		          }
                        else if(Math.Abs(s5) > Math.Abs(s6))
                        		       {
			                            B = gObjects[triangle[a].vertex2];
			                            C = gObjects[triangle[a].vertex1];
		                        }
                    		}
                	}
              else if (s5 > 0)
                	{
                    if (s6 > 0)
                    		{
                        if (s5 > s6)
                        		       {
		                            C = gObjects[triangle[a].vertex2];
		                            B = gObjects[triangle[a].vertex1];
                        		     }
                        else if (s5 < s6)
                        		      {
                            			C = gObjects[triangle[a].vertex1];
		                            B = gObjects[triangle[a].vertex2];
                        		        }
                    		}
                    else if (s6 < 0)
                    		{
		                        B = gObjects[triangle[a].vertex2];
		                        C = gObjects[triangle[a].vertex1];
                    		}

                }break;
      	  }

    }
    

We find all triangle and A, B, C.Now we have to control if P is inside triangle. This logic is same with blending animation. We have 4 point as A1, A2, A3 and P. We find det according to 3 point. Then, we find rate of point to last point.




         //control whether P is inside or outside
    //there is 4 point.ax,ay = 1st point, bx,by = 2nd point, cx,cy = 3rd point, px,py = 4th 	point
    //the last point is P point so we have to control this point whether is located in 	triangle
    int ControlInside(float ax, float ay, float bx, float bY, float cx, float cy, float px, 				float py)
        {
	 //blending rate
        float s, t, u;
		
	//det(A)
        float det = (ax * bY + ay * cx + bx * cy) - (bY * cx + ax * cy + ay * bx);

        if (det <= 0)
        	 {
            return 0;
        	   }
        else
        	 {
            // animation rate
            		s = (1 / det) * ((bY - cy) * px + (cx - bx) * py + (bx * cy - cx * bY));
	            t = (1 / det) * ((cy - ay) * px + (ax - cx) * py + (cx * ay - ax * cy));
	            u	 = (1 / det) * ((ay - bY) * px + (bx - ax) * py + (ax * bY - bx * ay));

            if (s >= 0 && t >= 0 && u >= 0)
            	           {
                return 1;
            		}
            return 0;
        	}
    }


if P is inside the triangle then return 1 else return 0.



Control function also prapared.Now, first we have to control if P is inside the triangle , we take that triangle and compare with other triangle which is consisting of P. Finally we find smallest triangle which is consisting of P. How to calculate smallest triangle? We have 3 point. We find distance of 3 point according to each other.
Distance A-B, A-C, B-C.

	//find smallest triangle containing of P
    void FindMinTriangle ()
       {
        float minCircle = 0;
	 for (int i = 0; i < triangle.Length; i++) {        
            //Assignt A,B,C //A,B,C is global variables
            AssignABC(i);

            //To control so that P is inside or outside
	      if ((ControlInside(A.transform.position.x,A.transform.position.z,
             B.transform.position.x,B.transform.position.z,
             C.transform.position.x,C.transform.position.z,
             P.transform.position.x,P.transform.position.z)) == 1)
             {

                //distance between A-B
                float x = (Mathf.Pow(Mathf.Abs 											(gObjects[triangle[i].vertex1].transform.position.x -                           				gObjects[triangle[i].vertex2].transform.position.x),2) +         		  Mathf.Pow(Mathf.Abs(gObjects[triangle[i].vertex1].transform.position.z - 		                               gObjects[triangle[i].vertex2].transform.position.z),2));
                //distance between A-C
                float y = Mathf.Pow(Mathf.Abs   										(gObjects[triangle[i].vertex1].transform.position.x -   					gObjects[triangle[i].vertex3].transform.position.x),2) +              		  Mathf.Pow(Mathf.Abs(gObjects[triangle[i].vertex1].transform.position.z - 				gObjects[triangle[i].vertex3].transform.position.z),2);
                


		// distance between B-C
                float z = Mathf.Pow(Mathf.Abs 											(gObjects[triangle[i].vertex2].transform.position.x -                          				gObjects[triangle[i].vertex3].transform.position.x),2) +        	  			Mathf.Pow(Mathf.Abs(gObjects[triangle[i].vertex2].transform.position.z - 					gObjects[triangle[i].vertex3].transform.position.z),2);
                //root of x,y,z because of hipotenus
                x = Mathf.Sqrt(x); // |A-B|
                y = Mathf.Sqrt(y);//  |A-C|
                z = Mathf.Sqrt(z);//  |B-C|
                //find minimum sum of the sides (min (a+b+c))
                //circleMin is the minimum of (a+b+c)
                //check if minCircle=0 , assign first value o minCircle
                if (minCircle == 0)
                	{
	                    minCircle = x + y + z;
              		      minTriangle.vertex1 = triangle[i].vertex1;
	                    minTriangle.vertex2 = triangle[i].vertex2;
              		      minTriangle.vertex3 = triangle[i].vertex3;                  
                	}           
	       //if minCircle is not 0, compare values for finding smallest triangle with 		smallest circle
                else
                	    {
                    if (x == 0 && y == 0 && z == 0)
                    		{              
                    		}
                    else
                   		{
                        if (minCircle > (x + y + z))
                        		        {
                            			minCircle = x + y + z;
		                            minTriangle.vertex1 = triangle[i].vertex1;
                            			minTriangle.vertex2 = triangle[i].vertex2;
		                            minTriangle.vertex3 = triangle[i].vertex3;
                        		          }
                    	}
                     }
              }    
       }
	Debug.Log("A: "+gObjects[minTriangle.vertex1].transform.name + "    B: " + 	 			  gObjects[minTriangle.vertex2].transform.name + "    C: " +		                   	     	         gObjects[minTriangle.vertex3].transform.name);
    }















































































































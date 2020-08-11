import 'package:flutter/material.dart';
import 'package:flutter_unity_widget_example/screens/home/home_screen.dart';

import 'screens/with_ark_screen.dart';

var MyApp = MaterialApp(
  title: 'Named Routes Demo',
  // Start the app with the "/" named route. In this case, the app starts
  // on the FirstScreen widget.
  initialRoute: '/',
  debugShowCheckedModeBanner: false,
  routes: {
  '/': (context) => HomeScreen(),
  '/ar': (context) => WithARkitScreen(),
  
  },
);

void main() => runApp(MyApp);
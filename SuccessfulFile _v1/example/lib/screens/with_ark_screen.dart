import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:flutter_unity_widget/flutter_unity_widget.dart';
import 'package:flutter_unity_widget_example/screens/constants.dart';
import 'package:flutter_unity_widget_example/screens/models/selectedproduct.dart';

import 'models/product.dart';

class WithARkitScreen extends StatefulWidget {
  final String text;
  final Product product;

  const WithARkitScreen({Key key, this.text, this.product}) : super(key: key);
  @override
  _WithARkitScreenState createState() => _WithARkitScreenState(this.product);
}

class _WithARkitScreenState extends State<WithARkitScreen> {
  final Product product;
  static final GlobalKey<ScaffoldState> _scaffoldKey =
      GlobalKey<ScaffoldState>();
  UnityWidgetController _unityWidgetController;
  String textHolder = 'Object to Instantiate';

  _WithARkitScreenState(this.product);

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Scaffold(
        key: _scaffoldKey,
        // appBar: AppBar(
        //   title: const Text('Unity Box Rotate'),
        // ),
        body: Stack(
          children: <Widget>[
            UnityWidget(
              onUnityViewCreated: onUnityCreated,
              isARScene: true,
              onUnityMessage: onUnityMessage,
            ),
            SafeArea(
              child: Padding(
                padding: const EdgeInsets.all(kDefaultPadding),
                child: Container(
                  child: IconButton(
                    icon: SvgPicture.asset("assets/icons/back.svg",
                        color: Colors.white),
                    onPressed: () {
                      Navigator.pop(context, '/');
                    },
                  ),
                ),
              ),
            ),
            Positioned(
              bottom: 10,
              left: 20,
              right: 20,
              child: Container(
                decoration:
                    BoxDecoration(borderRadius: BorderRadius.circular(1000)),
                child: Card(
                  elevation: 10,
                  child: Column(
                    children: <Widget>[
                      Padding(
                        padding: const EdgeInsets.only(top: 20),
                        child: Text("Object to Instantiate: " + product.title),
                      ),
                      SizedBox(
                        height: 10,
                      ),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                        children: <Widget>[
                          RaisedButton(
                            onPressed: () {
                            },
                            child: Text('Menu'),
                          ),
                          RaisedButton(
                            onPressed: () => instantiateThis(product.title),
                            child: Text('Instantiate Me'),
                          ),
                          RaisedButton(
                            onPressed: () {},
                            child: Text('Tap on Object'),
                          ),
                        ],
                      ),
                    ],
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  void setRotationSpeed(String speed) {
    _unityWidgetController.postMessage(
      'Cube',
      'SetRotationSpeed',
      speed,
    );
  }

  void instantiateThis(String message){
    _unityWidgetController.postMessage('AR Session Origin', 'InstantiateThis', message);
  }

  void onUnityMessage(controller, message) {
    print('Received message from unity: ${message.toString()}');
    setState(() {
      textHolder = message.toString();
    });
  }

  // Callback that connects the created controller to the unity controller
  void onUnityCreated(controller) {
    this._unityWidgetController = controller;
  }
}

import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:flutter_unity_widget_example/screens/models/product.dart';
import 'package:flutter_unity_widget_example/screens/models/selectedproduct.dart';
import 'package:flutter_unity_widget_example/screens/with_ark_screen.dart';

import '../constants.dart';

class AddToCart extends StatelessWidget {
  const AddToCart({
    Key key,
    @required this.product,
  }) : super(key: key);

  final Product product;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: kDefaultPadding),
      child: Row(
        children: <Widget>[
          Container(
            margin: EdgeInsets.only(right: kDefaultPadding),
            height: 50,
            width: 58,
            decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(18),
                border: Border.all(color: product.color)),
            child: IconButton(
                icon: SvgPicture.asset("assets/icons/virtual-reality.svg",
                    color: product.color),
                onPressed: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => WithARkitScreen(product: this.product,),
                      ));
                }),
          ),
          Expanded(
            child: SizedBox(
              height: 50,
              child: FlatButton(
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(18),
                ),
                color: product.color,
                onPressed: () {},
                child: Text("Buy Now".toUpperCase(),
                    style: TextStyle(
                        fontSize: 17,
                        fontWeight: FontWeight.bold,
                        color: Colors.white)),
              ),
            ),
          )
        ],
      ),
    );
  }
}

import 'package:flutter/material.dart';

import '../../constants.dart';

class CartCounter extends StatefulWidget {
  @override
  _CartCounterState createState() => _CartCounterState();
}

class _CartCounterState extends State<CartCounter> {
  int numOfItems = 1;

  @override
  Widget build(BuildContext context) {
    return Row(
      children: <Widget>[
        buildOutlineButton(icon: Icons.remove, press: () {
          setState(() {
            if(numOfItems > 1){
              numOfItems--;
            }
            
          });
        }),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: kDefaultPadding / 2),
          child: Text(
            // if our item is less than 10 then it shows 01 02 like that
            numOfItems.toString().padLeft(2, "0"),
            style: Theme.of(context).textTheme.headline,
          ),
        ),
        buildOutlineButton(icon: Icons.add, press: () {
          setState(() {
            numOfItems++;
          });
        }),
      ],
    );
  }
}

SizedBox buildOutlineButton({IconData icon, Function press}) {
  return SizedBox(
      width: 32,
      height: 40,
      child: OutlineButton(
          padding: EdgeInsets.zero,
          onPressed: press,
          child: Icon(icon),
          shape:
              RoundedRectangleBorder(borderRadius: BorderRadius.circular(13))));
}

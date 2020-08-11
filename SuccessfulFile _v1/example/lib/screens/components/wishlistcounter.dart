import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:flutter_unity_widget_example/screens/details/components/cart_counter.dart';


class WishListCounter extends StatelessWidget {
  const WishListCounter({
    Key key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: <Widget>[
          CartCounter(),
          Container(
              padding: EdgeInsets.all(8),
              height: 32,
              width: 32,
              decoration: BoxDecoration(
                  color: Color(0xFFFF6464),
                  shape: BoxShape.circle),
              child:
                  SvgPicture.asset("assets/icons/heart.svg"))
        ]);
  }
}
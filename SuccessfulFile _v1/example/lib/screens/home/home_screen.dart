import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:flutter_unity_widget_example/screens/components/body.dart';

import '../constants.dart';


class HomeScreen extends StatelessWidget {
  const HomeScreen({Key key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: buildAppBar(),
      body: Body(),

    );
  }
}


AppBar buildAppBar(){
  return AppBar(
        backgroundColor: Colors.white,
        elevation: 0,
        leading: IconButton(
          icon: SvgPicture.asset("assets/icons/back.svg"),
          onPressed: () {},
        ),
        actions: <Widget>[
          IconButton(
            icon:
                SvgPicture.asset("assets/icons/search.svg", color: kTextColor),
            onPressed: () {},
          ),
          IconButton(
            icon: SvgPicture.asset("assets/icons/cart.svg", color: kTextColor),
            onPressed: () {},
          ),
          SizedBox(width: kDefaultPadding / 2)
        ],
      );
}

import 'package:flutter/material.dart';

class Product {
  final String image, title, description, size;
  final int price, id;
  final Color color;

  Product(
      {this.image,
      this.title,
      this.description,
      this.price,
      this.size,
      this.id,
      this.color});
}

List<Product> products = [
  Product(
      id: 1,
      title: "Hexagon Plate",
      price: 58000,
      size: "S",
      description: dummyText,
      image: "assets/images/Hexagon_Plate.jpeg",
      color: Color(0xFF3D82AE)),
  Product(
      id: 2,
      title: "Aira Tray",
      price: 128000,
      size: "M",
      description: dummyText,
      image: "assets/images/Aira_Tray.jpeg",
      color: Color(0xFF3D82AE)),
  Product(
      id: 3,
      title: "Hexagon Coaster",
      price: 12000,
      size: "S",
      description: dummyText,
      image: "assets/images/Hexagon_Coaster.jpeg",
      color: Color(0xFF3D82AE)),
  Product(
      id: 4,
      title: "Hexagon Tray",
      price: 150000,
      size: "L",
      description: dummyText,
      image: "assets/images/Hexagon_Tray.jpeg",
      color: Color(0xFF3D82AE)),
  Product(
      id: 5,
      title: "Storage Box",
      price: 128000,
      size: "L",
      description: dummyText,
      image: "assets/images/Storage_Box.jpeg",
      color: Color(0xFF3D82AE)),
  Product(
    id: 6,
    title: "Round Tray",
    price: 65000,
    size: "M",
    description: dummyText,
    image: "assets/images/Round_Tray.jpeg",
    color: Color(0xFF3D82AE),
  ),
];

String dummyText =
    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since. When an unknown printer took a galley.";

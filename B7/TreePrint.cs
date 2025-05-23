﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B7 {
    static class TreePrint {
        internal class NodeInfo {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
        public static void Print(this TreeNode root, int topMargin = 2, int leftMargin = 2) {
            var colorB = Console.BackgroundColor;
            var colorF = Console.ForegroundColor;
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root;
            try {
                for (int level = 0; next != null; level++) {
                    var item = new NodeInfo { Node = next, Text = next.Val.ToString(" 0 ") };
                    if (level < last.Count) {
                        item.StartPos = last[level].EndPos + 2;
                        last[level] = item;
                    } else {
                        item.StartPos = leftMargin;
                        last.Add(item);
                    }
                    if (level > 0) {
                        item.Parent = last[level - 1];
                        if (next == item.Parent.Node.Left) {
                            item.Parent.Left = item;
                            item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                        } else {
                            item.Parent.Right = item;
                            item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                        }
                    }
                    next = next.Left != null ? next.Left : next.Right;
                    for (; next == null; item = item.Parent) {
                        Print(item, rootTop + 2 * level);
                        if (--level < 0) break;
                        if (item == item.Parent.Left) {
                            item.Parent.StartPos = item.EndPos;
                            next = item.Parent.Node.Right;
                        } else {
                            if (item.Parent.Left == null)
                                item.Parent.EndPos = item.StartPos;
                            else
                                item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                        }
                    }
                }
            }
            catch(ArgumentOutOfRangeException error) {
                Console.BackgroundColor = colorB;
                Console.ForegroundColor = colorF;
                Console.Clear();
                if (error.Message.Contains("buffer")) Console.WriteLine("The tree is too large to be printed in the console!");
                else Console.WriteLine(error.Message);
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }
        private static void Print(NodeInfo item, int top) {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null) PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null) PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }
        private static void PrintLink(int top, string start, string end, int startPos, int endPos) {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }
        private static void Print(string text, int top, int left, int right = -1) {
            if (left > Console.BufferWidth) throw new ArgumentOutOfRangeException("left", "buffer");
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + text.Length;
            while (Console.CursorLeft < right
                && Console.CursorLeft < Console.BufferWidth - text.Length -1) Console.Write(text);
        }
        private static void SwapColors() {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
    }
}
